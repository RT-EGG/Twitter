using System.Windows.Forms;

namespace Imetter
{
    public partial class FormApplicaionKeysQuery : Form
    {
        public FormApplicaionKeysQuery()
        {
            InitializeComponent();
        }

        public string APIKey => TextAPIKey.Text;
        public string SecretKey => TextSecretKey.Text;
    }
}
