using System.Windows.Controls;

namespace SamleProgram
{
    public class Collection
    {
        public Collection(int id, string name, bool status)
        {
            this._id = id;
            this._name = name;
            this._status = status;
        }

        public int _id { get; set; }
        public string _name { get; set; }
        public bool _status { get; set; }
    }
}
