 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skolnik
{
    public class List_Assessment
    {
        public List<Assessment> LAssessment; //= new List<Assessment>();
        public List_Assessment()
        {
            LAssessment = new List<Assessment>();
        }
    }
    [Serializable]
    public class Assessment
    {
        public string subject { get; set; }
        public int assessment { get; set; }

        public Assessment(string sub, int asse)
        {
            this.subject = sub;
            this.assessment = asse;
        }
        public Assessment()
        {

        }
        public override string ToString()
        {
            return string.Format("{0} {1}, ", subject, assessment.ToString());
        }
    }
}
