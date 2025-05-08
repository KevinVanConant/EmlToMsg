using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MimeKit;
using MsgKit;

namespace EmlToMsg
{
    public partial class Form1 : Form
    {
        private string sourceFolder = "";
        private string targetFolder = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectSource_Click(object sender, EventArgs e)
        {
            using var dlg = new FolderBrowserDialog();
            dlg.Description = "Select folder containing .eml files";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sourceFolder = dlg.SelectedPath;
                lblSource.Text = sourceFolder;
            }
        }

        private void btnSelectTarget_Click(object sender, EventArgs e)
        {
            using var dlg = new FolderBrowserDialog();
            dlg.Description = "Select output folder for .msg files";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                targetFolder = dlg.SelectedPath;
                lblTarget.Text = targetFolder;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(sourceFolder) || !Directory.Exists(targetFolder))
            {
                MessageBox.Show("Please select both source and destination folders.");
                return;
            }

            int count = 0;

            foreach (var emlPath in Directory.GetFiles(sourceFolder, "*.eml"))
            {
                try
                {
                    var mime = MimeMessage.Load(emlPath);
                    var from = mime.From.Mailboxes.FirstOrDefault();
                    var subject = mime.Subject ?? "(no subject)";
                    var msgSender = new MsgKit.Sender(
    from?.Address ?? "unknown@example.com",
    from?.Name ?? "Unknown"
);

                    using var email = new Email(msgSender, null, subject);

                    email.BodyText = mime.TextBody ?? "";
                    email.BodyHtml = mime.HtmlBody ?? "";

                    foreach (var to in mime.To.Mailboxes)
                        email.Recipients.AddTo(to.Address, to.Name);
                    foreach (var cc in mime.Cc.Mailboxes)
                        email.Recipients.AddCc(cc.Address, cc.Name);
                    foreach (var bcc in mime.Bcc.Mailboxes)
                        email.Recipients.AddBcc(bcc.Address, bcc.Name);

                    foreach (var part in mime.Attachments.OfType<MimePart>())
                    {
                        var name = part.FileName ?? Guid.NewGuid().ToString();
                        var path = Path.Combine(Path.GetTempPath(), name);
                        using (var fs = File.Create(path))
                            part.Content.DecodeTo(fs);
                        email.Attachments.Add(path);
                        File.Delete(path);
                    }

                    var baseName = Path.GetFileNameWithoutExtension(emlPath);
                    var msgPath = Path.Combine(targetFolder, baseName + ".msg");
                    email.Save(msgPath);
                    count++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"> Error converting {Path.GetFileName(emlPath)}: {ex.Message}");
                }
            }

            MessageBox.Show($"> {count} file(s) converted.");
        }
    }
}