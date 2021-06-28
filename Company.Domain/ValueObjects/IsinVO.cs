using System.Text.RegularExpressions;

namespace Company.Domain.ValueObjects
{
    public class IsinVO : ValueObject<string>
    {
        public IsinVO() { }
        public IsinVO(string value)
        {
            this.Value = value;
        }

        public override bool IsValid()
        {
            return new Regex("^(([A-Z]){2})(([A-Z0-9]){10})$").IsMatch(this.Value);
        }
    }
}
