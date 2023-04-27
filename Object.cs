using System.Windows.Controls;

namespace SamleProgram
{
    public class Object
    {
        public Object(int id, int collectionId, string name, bool status)
        {
            this._id = id;
            this._collectionId = collectionId;
            this._name = name;
            this._status = status;
        }

        public int _id { get; set; }
        public int _collectionId { get; set; }
        public string _name { get; set; }
        public bool _status { get; set; }
    }
}
