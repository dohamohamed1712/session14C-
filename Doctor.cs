using System;
using System.Collections.Generic;
using System.Text;

namespace session14C_3
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;

        // Many-to-Many with Patient (through Appointment)
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
