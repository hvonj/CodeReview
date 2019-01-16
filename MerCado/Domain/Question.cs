using System;
using System.Collections.Generic;
using System.Text;

namespace MerCado.Domain
{
    public class Question
    {
        public int ID { get; set; }
        public string question { get; set; }
        public int questionTypeID { get; set; }
        public bool genericQuestion { get; set; }
        public int answerID { get; set; }
    }
}
