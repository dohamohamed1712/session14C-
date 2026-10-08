using System;
using System.Collections.Generic;
using System.Text;

namespace session14C_3
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        // Many-to-Many with Doctor (through Appointment)
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
