
using Microsoft.EntityFrameworkCore;
using session14C_3;

using var context = new HealthCareDbContext();

var patient = new Patient { Name = "Mona", DateOfBirth = new DateTime(1995, 3, 12) };
var doctor = new Doctor { Name = "Dr. Khaled", Specialization = "Cardiology" };

patient.Appointments.Add(new Appointment
{
    Doctor = doctor,
    AppointmentDate = new DateTime(2026, 10, 15, 10, 30, 0)
});

context.Patients.Add(patient);
context.SaveChanges();

var patients = context.Patients
    .Include(p => p.Appointments)
        .ThenInclude(a => a.Doctor)
    .ToList();

foreach (var p in patients)
{
    Console.WriteLine($"Patient: {p.Name}");
    foreach (var a in p.Appointments)
        Console.WriteLine($"  - {a.Doctor.Name} ({a.Doctor.Specialization}) on {a.AppointmentDate:g}");
}