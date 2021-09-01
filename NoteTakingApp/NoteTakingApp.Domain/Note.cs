using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteTakingApp.Domain
{
    public class Note
    {

        private string _text;

        public int Id { get; set; }

        public string Text
        {
            get => _text;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("text is required");
                }
                _text = value;
            }
        }

        public List<string> Tags { get; set; }

        [DisplayName("Word count")]
        public int WordCount
        {
            get
            {
                var delimiters = new char[] { ' ', '\r', '\n' };
                return Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
            }
        }
    }
}
