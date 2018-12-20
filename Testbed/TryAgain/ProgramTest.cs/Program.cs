using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryAgain;

namespace ProgramTest.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertData.Schema = "TEST";



                //InsertData.WriteUser("Sloane", "Gorse", "sgorse0@last.fm");
                //InsertData.WriteUser("Corissa", "Duffield", "cduffield1@berkeley.edu");
                //InsertData.WriteUser("Berri", "Bromby", "bbromby2@accuweather.com");
                //InsertData.WriteUser("Fawnia", "Grebbin", "fgrebbin3@networksolutions.com");
                //InsertData.WriteUser("Jere", "Stuke", "jstuke4@a8.net");
                //InsertData.WriteUser("Kristofer", "Chastenet", "kchastenet5@nsw.gov.au");
                //InsertData.WriteUser("Marney", "Langlands", "mlanglands6@vinaora.com");
                //InsertData.WriteUser("Hermina", "Gatch", "hgatch7@yellowbook.com");
                //InsertData.WriteUser("Ardeen", "Engley", "aengley8@unblog.fr");
			    //InsertData.WriteUser("newUser", "NewUserLast", "NU@OIT.edu");
			
            QueryData.SelectAllFromTable("TEST.Users");

                //InsertData.WriteSupervisor(1, "8675309", new DateTime(1997, 06, 18), new DateTime(1997, 06, 19), true);
                //InsertData.WriteRelationship(1, 5, new DateTime(2015, 4, 12), new DateTime(2015, 5, 1));
        }
    }
}
