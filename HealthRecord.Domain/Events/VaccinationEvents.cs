using System;
using System.Collections.Generic;
using System.Text;

namespace HealthRecord.Domain.Events
{
    public class VaccinationEvents
    {
        

            public class CreatedVaccination
            {
                public Guid VaccinationId { get; set; }

                 public Guid HealthRecordId { get; set; }
                public string Name { get; set; }

                public DateTime Date { get; set; }

                public bool IsDeleted { get; set; }


            }

            public class UpdatedVaccination
            {
            public Guid VaccinationId { get; set; }
            public string Name { get; set; }

            public DateTime Date { get; set; }

            public bool IsDeleted { get; set; }



        }

        public class DeletedVacciantion
            {

            public Guid VaccinationId { get; set; }
            public string Name { get; set; }

            public DateTime Date { get; set; }

            public bool IsDeleted { get; set; }


        }
    }
    
}
