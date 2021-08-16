using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouchsidesTechAssignment.LocalServices;

namespace TouchsidesTechAssignment
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            var fileContent = GetFileContent();            
            ProcessResults(fileContent);              
        }

        private async Task ProcessResults(string fileContent)
        {
            WordFrequency wordFrequency = new WordFrequency();
            lblMostFrequentWord.Text = await wordFrequency.GetMostFrequentWord(fileContent);
            lblMostFrequentSevenCharWord.Text = await wordFrequency.GetMostFrequentSevenCharWord(fileContent);
            lblHighestScoringWord.Text = await wordFrequency.GetHighestScoringWord(fileContent);
        }
        private string GetFileContent()
        {
            string path = Server.MapPath(fpFile.FileName);
            fpFile.PostedFile.SaveAs(path);
            string text = System.IO.File.ReadAllText(path);
            System.IO.File.Delete(path);
            return text;
        }
    }
}