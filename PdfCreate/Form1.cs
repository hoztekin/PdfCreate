using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PdfCreate
{
	public partial class PdfCreate : Form
	{
		public PdfCreate()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file | *.pdf", ValidateNames = true }) 
			{

				if (sfd.ShowDialog() == DialogResult.OK)
				{
					iTextSharp.text.Document pdfcreate = new iTextSharp.text.Document(PageSize.A4.Rotate());
					PdfWriter.GetInstance(pdfcreate, new FileStream(sfd.FileName, FileMode.Create));
					pdfcreate.Open();
					pdfcreate.AddAuthor(textBox1.Text);
					pdfcreate.AddCreator(textBox2.Text);	
					pdfcreate.AddSubject(textBox3.Text);
					pdfcreate.AddTitle(textBox4.Text);
					pdfcreate.AddKeywords(textBox5.Text);
					pdfcreate.Add(new iTextSharp.text.Paragraph(richTextBox1.Text));
					pdfcreate.Close();	
				}
			}
		}
	}
}