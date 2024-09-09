using FluentValidation;
using HMS.Data.Models;
using System;

public class PatientValidator : AbstractValidator<Patient>
{
    public PatientValidator()
    {
        RuleFor(p => p.Id).NotEmpty().Must(BeAValidGuid);
        RuleFor(p => p.Name).NotEmpty().MaximumLength(100);
        RuleFor(p => p.Age).InclusiveBetween(0, 120);
        RuleFor(p => p.Gender).IsInEnum();
        RuleFor(p => p.ContactNumber).Matches(@"^\d{10,15}$");
        RuleFor(p => p.Email).EmailAddress().When(p => !string.IsNullOrEmpty(p.Email));
        RuleFor(p => p.Address).SetValidator(new AddressValidator());
        RuleFor(p => p.Id).NotEmpty().Must(guid => BeAValidGuid(guid));
        RuleFor(p => p.AdmissionDate).LessThanOrEqualTo(DateTime.Now);
        RuleFor(p => p.DischargeDate).Must(BeLaterThanAdmissionDate).When(p => p.DischargeDate.HasValue);
    }

    private bool BeAValidGuid(Guid guid)
    {
        return guid != Guid.Empty;
    }

    private bool BeLaterThanAdmissionDate(Patient patient, DateTime? dischargeDate)
    {
        return dischargeDate > patient.AdmissionDate;
    }
}