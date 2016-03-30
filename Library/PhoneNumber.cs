namespace TelefoneLibrary
{
    using System.Diagnostics.CodeAnalysis;

    public class PhoneNumber
    {
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Justification = "It's immutable.")]
        public readonly string AreaCode;

        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Justification = "It's immutable.")]
        public readonly string Number;

        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Justification = "It's immutable.")]
        public readonly bool Landline;

        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Justification = "It's immutable.")]
        public readonly State State;

        internal PhoneNumber(string areaCode, string number, bool landline, State state)
        {
            AreaCode = areaCode;
            Number = number;
            Landline = landline;
            State = state;
        }

        public static bool operator ==(PhoneNumber a, PhoneNumber b)
        {
            return (object.ReferenceEquals(a, null) && object.ReferenceEquals(b, null)) ||
                !object.ReferenceEquals(a, null) && !object.ReferenceEquals(b, null) &&
                a.AreaCode == b.AreaCode && a.Number == b.Number && a.Landline == b.Landline && a.State == b.State;
        }

        public static bool operator !=(PhoneNumber a, PhoneNumber b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            var phone = obj as PhoneNumber;
            return phone != null && phone == this;
        }

        public override int GetHashCode()
        {
            return AreaCode.GetHashCode() ^ Number.GetHashCode() ^ Landline.GetHashCode() ^ State.GetHashCode();
        }
    }
}
