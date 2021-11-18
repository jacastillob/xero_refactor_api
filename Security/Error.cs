using System;
namespace RefactorThis.Security
{
    public class Error : Exception
    {

        public int code { get; set; }
        public string component { get; set; }
        public string type { get; set; }//ERROR, WARNING
        

        public Error(string message, string component,int code)
            : base(message)
        {
            this.code = code;
            this.type = "WARNING";
            this.code = code;
        }

        public Error(string message, string component,  int code, Exception inner)
            : base(message, inner)
        {
            this.component = component;
            this.type = "ERROR";
            this.code = code;
        }

        public Error(string message, bool options)
            : base(message)
        {
            this.type = "OPTIONS";
        }



    }
}
