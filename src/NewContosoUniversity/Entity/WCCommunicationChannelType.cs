using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewContosoUniversity.Entity
{
    public class WCCommunicationChannelType
    {
        private int _communicationchanneltypeID;
        private string _communicationchanneltypeDesc;

        /// <summary>
        /// Entity Framework relies on every entity having a key value that it uses for tracking entities. 
        /// One of the conventions that code first depends on is how it implies which property is the key in each of the code first classes. 
        /// That convention is to look for a property named “Id” or one that combines the class name and “Id”, such as “WCCommunicationChannelTypeID”. 
        /// The property will map to a primary key column in the database
        /// But what if they didn’t?
        ///  If code first does not find a property that matches this convention it will throw an exception because of Entity Framework’s requirement 
        ///  that you must have a key property. 
        ///  You can use the [key] annotation to specify which property is to be used as the EntityKey.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CommunicationChannelTypeID
        {
            get
            {
                return _communicationchanneltypeID;
            }

            set
            {
                _communicationchanneltypeID = value;
            }

        }
        public string CommunicationChannelTypeDesc
        {
            get
            {
                return _communicationchanneltypeDesc;
            }

            set
            {
                _communicationchanneltypeDesc = value;
            }

        }

    }
}
