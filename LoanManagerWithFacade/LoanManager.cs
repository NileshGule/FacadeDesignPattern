using Common;

namespace LoanManagerWithFacade
{
    public class LoanManager
    {
        public void Process(LoanApplication application)
        {
            ILoanApplicationVerifier loanApplicationVerifier = new LoanApplicationVerifier();

            bool isEligible = loanApplicationVerifier.IsEligible(application);

            application.IsApproved = isEligible;

            NotificationService notificationService = new NotificationService();
            notificationService.Notify(application);
        }
    }
}