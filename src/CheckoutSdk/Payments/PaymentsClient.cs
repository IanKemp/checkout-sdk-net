using Checkout.Payments.Request;
using Checkout.Payments.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Checkout.Payments
{
    public class PaymentsClient : AbstractClient, IPaymentsClient
    {
        private const string PaymentsPath = "payments";

        public PaymentsClient(
            IApiClient apiClient,
            CheckoutConfiguration configuration) : base(apiClient, configuration, SdkAuthorizationType.SecretKeyOrOAuth)
        {
        }

        public Task<PaymentResponse> RequestPayment(PaymentRequest paymentRequest,
            string idempotencyKey = null,
            CancellationToken cancellationToken = default)
        {
            CheckoutUtils.ValidateParams("paymentRequest", paymentRequest);
            return ApiClient.Post<PaymentResponse>(
                PaymentsPath,
                SdkAuthorization(),
                paymentRequest,
                cancellationToken,
                idempotencyKey);
        }

        public Task<PayoutResponse> RequestPayout(PayoutRequest payoutRequest,
            string idempotencyKey = null,
            CancellationToken cancellationToken = default)
        {
            CheckoutUtils.ValidateParams("payoutRequest", payoutRequest);
            return ApiClient.Post<PayoutResponse>(
                PaymentsPath,
                SdkAuthorization(),
                payoutRequest,
                cancellationToken,
                idempotencyKey);
        }

        public Task<PaymentsQueryResponse> GetPaymentsList(
            PaymentsQueryFilter queryFilter,
            CancellationToken cancellationToken = default)
        {
            CheckoutUtils.ValidateParams("queryFilter", queryFilter);
            return ApiClient.Query<PaymentsQueryResponse>(
                PaymentsPath,
                SdkAuthorization(),
                queryFilter,
                cancellationToken);
        }

        public Task<GetPaymentResponse> GetPaymentDetails(
            string paymentId,
            CancellationToken cancellationToken = default)
        {
            CheckoutUtils.ValidateParams("paymentId", paymentId);
            return ApiClient.Get<GetPaymentResponse>(BuildPath(PaymentsPath, paymentId),
                SdkAuthorization(),
                cancellationToken);
        }

        public Task<ItemsResponse<PaymentAction>> GetPaymentActions(
            string paymentId,
            CancellationToken cancellationToken = default)
        {
            CheckoutUtils.ValidateParams("paymentId", paymentId);
            return ApiClient.Get<ItemsResponse<PaymentAction>>(BuildPath(PaymentsPath, paymentId, "actions"),
                SdkAuthorization(),
                cancellationToken);
        }

        public Task<CaptureResponse> CapturePayment(
            string paymentId,
            CaptureRequest captureRequest,
            string idempotencyKey = null,
            CancellationToken cancellationToken = default)
        {
            CheckoutUtils.ValidateParams("paymentId", paymentId);
            return ApiClient.Post<CaptureResponse>(BuildPath(PaymentsPath, paymentId, "captures"),
                SdkAuthorization(),
                captureRequest,
                cancellationToken,
                idempotencyKey);
        }

        public Task<RefundResponse> RefundPayment(
            string paymentId,
            RefundRequest refundRequest = null,
            string idempotencyKey = null,
            CancellationToken cancellationToken = default)
        {
            CheckoutUtils.ValidateParams("paymentId", paymentId);
            return ApiClient.Post<RefundResponse>(BuildPath(PaymentsPath, paymentId, "refunds"),
                SdkAuthorization(),
                refundRequest,
                cancellationToken,
                idempotencyKey);
        }

        public Task<VoidResponse> VoidPayment(
            string paymentId,
            VoidRequest voidRequest = null,
            string idempotencyKey = null,
            CancellationToken cancellationToken = default)
        {
            CheckoutUtils.ValidateParams("paymentId", paymentId);
            return ApiClient.Post<VoidResponse>(BuildPath(PaymentsPath, paymentId, "voids"),
                SdkAuthorization(),
                voidRequest,
                cancellationToken,
                idempotencyKey);
        }

        public Task<AuthorizationResponse> IncrementPaymentAuthorization(
            string paymentId,
            AuthorizationRequest authorizationRequest = null,
            string idempotencyKey = null,
            CancellationToken cancellationToken = default)
        {
            CheckoutUtils.ValidateParams("paymentId", paymentId);
            return ApiClient.Post<AuthorizationResponse>(BuildPath(PaymentsPath, paymentId, "authorizations"),
                SdkAuthorization(),
                authorizationRequest,
                cancellationToken,
                idempotencyKey);
        }
    }
}