

BreakevenApi
================

BreakevenApi is a medical scheduling and record-keeping application.

Developed for the breakeven process of the 2024 internship program at Stone Co with the aim of improving the author's knowledge in C#, Dotnet Core, Entity Framework, and Unit Testing.

Some tests still need to be implemented, and modifications are likely.



### Features

* Manage medical consultations, including creating, finishing, and scheduling appointments
* Create and manage patient records
* Generate reports
* Manage medical schedules for doctors

### Services

* `ConsultaService`: manages medical consultations, patient records and reports.
* `AgendaService`: manages medical schedules for reports.

### Endpoints

All enndpoints are listed in the swagger documentation, which can be accessed at `http://localhost:8080/swagger-ui.html`.
Those are the most important ones:

* `/paciente/adds-missing-data`: should be used before the consultation starts and the pacient is a new one, therefore needing to add some missing data
* `/consulta/cronograma`: retrieves a list of all appointments today, with information about all the medis, patients and the time of the appointment
* `/consulta/finaliza`: finishes a consultation and register all the information for the report
* `/consulta/horariolivre/`: gets a list of all the free time slots for a doctor, by CRM and Date
* `/consulta/agenda-consulta/`: schedules a new appointment, checking all the necessary conditions
* 





