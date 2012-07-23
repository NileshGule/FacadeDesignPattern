using Common;

namespace LoanManagerWithFacade
{
    public class LoanApplicationVerifier : ILoanApplicationVerifier
    {
        public bool IsEligible(LoanApplication application)
        {
            bool personalDetailsAreValid = new PersonalDetailVerifier().VerifyDetails(application);

            bool professionalDetailsAreValid = new ProfessionalDetailVerifier().VerifyDetails(application);

            bool creditHistoryVerified = new CreditHistoryVerifier().Verify(application);

            bool isPreferredDeveloper = new DeveloperVerifier().IsPreferredDeveloper(application.DeveloperName);

            bool isProjectApproved = isPreferredDeveloper ? true : new ProjectVerifier().IsBlackListedProject(application.ProjectName);

            return personalDetailsAreValid
                && professionalDetailsAreValid
                && creditHistoryVerified
                && isProjectApproved;
        }
    }
}