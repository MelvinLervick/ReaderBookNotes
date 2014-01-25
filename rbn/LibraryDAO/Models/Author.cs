using System.Collections;

namespace LibraryDAO.Models
{
    public class Author
    {
        public string Name
        {
            get { return string.Format( "{2}, {0} {1}", FirstName, MiddleName, LastName ); }

            set
            {
                var name = value;
                if ( name.Contains( "," ) )
                {
                    var nameList= name.Split( ',' );
                    LastName = nameList[0];

                    var firstAndMiddle = new ArrayList();
                    firstAndMiddle.AddRange( nameList[1].Split( ' ' ) );
                    FirstName = firstAndMiddle[0].ToString();
                    firstAndMiddle.RemoveAt( 0 );
                    if ( firstAndMiddle.Count > 0 )
                    {
                        MiddleName = firstAndMiddle.ToString();
                    }
                }
                else
                {
                    var nameList = new ArrayList();
                    nameList.AddRange(name.Split( ' ' ));
                    FirstName = nameList[0].ToString();
                    nameList.RemoveAt( 0 );
                    if ( nameList.Count > 1 )
                    {
                        MiddleName = nameList[0].ToString();
                        nameList.RemoveAt( 0 );
                    }
                    LastName = nameList.ToString();
                }
            }
        }

        public string FirstName
        {
            get;
            set;
        }

        public string MiddleName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }
    }
}
