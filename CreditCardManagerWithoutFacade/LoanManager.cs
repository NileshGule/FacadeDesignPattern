using Common;

namespace LoanManagerWithoutFacade
{
    public class LoanManager
    {
        public void Process(LoanApplication application)
        {
            bool personalDetailsAreValid = new PersonalDetailVerifier().VerifyDetails(application);

            bool professionalDetailsAreValid = new ProfessionalDetailVerifier().VerifyDetails(application);

            bool creditHistoryVerified = new CreditHistoryVerifier().Verify(application);

            bool isPreferredDeveloper = new DeveloperVerifier().IsPreferredDeveloper(application.DeveloperName);

            bool isProjectApproved = isPreferredDeveloper ? true : new ProjectVerifier().IsBlackListedProject(application.ProjectName);

            bool isEligible = personalDetailsAreValid
                && professionalDetailsAreValid
                && creditHistoryVerified
                && isProjectApproved;

            application.IsApproved = isEligible;

            NotificationService notificationService = new NotificationService();
            notificationService.Notify(application);
        }
    }
}