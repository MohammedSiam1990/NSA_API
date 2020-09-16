namespace POS.Common
{

    /// <summary>
    /// String value attribute.
    /// </summary>
    /// <createdby>AhmedMustafa</createdby>
    /// <createdon>29/07/2017</createdon>
    public class StringValueAttribute : System.Attribute
    {

        private string _value;

        /// <summary>
        /// Constructor for StringValueAttribute class.
        /// </summary>
        /// <param name="value">string value of the enum.</param>
        public StringValueAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

    }
}
