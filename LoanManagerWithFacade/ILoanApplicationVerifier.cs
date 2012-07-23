using Common;

namespace LoanManagerWithFacade
{
    public interface ILoanApplicationVerifier
    {
        bool IsEligible(LoanApplication application);
    }
}