﻿using Checkout.Payments.Previous.Request;
using Checkout.Payments.Previous.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Checkout.Payments.Previous
{
    public interface IPaymentsClient
    {
        Task<PaymentResponse> RequestPayment(
            PaymentRequest paymentRequest,
            string idempotencyKey = null,
            CancellationToken cancellationToken = default);

        Task<PaymentResponse> RequestPayout(
            PayoutRequest payoutRequest,
            string idempotencyKey = null,
            CancellationToken cancellationToken = default);

        Task<PaymentsQueryResponse> GetPaymentsList(
            PaymentsQueryFilter queryFilter,
            CancellationToken cancellationToken = default);

        Task<GetPaymentResponse> GetPaymentDetails(
            string paymentId,
            CancellationToken cancellationToken = default);

        Task<ItemsResponse<PaymentAction>> GetPaymentActions(
            string paymentId,
            CancellationToken cancellationToken = default);

        Task<CaptureResponse> CapturePayment(
            string paymentId,
            CaptureRequest captureRequest,
            string idempotencyKey = null,
            CancellationToken cancellationToken = default);

        Task<RefundResponse> RefundPayment(
            string paymentId,
            RefundRequest refundRequest = null,
            string idempotencyKey = null,
            CancellationToken cancellationToken = default);

        Task<VoidResponse> VoidPayment(
            string paymentId,
            VoidRequest voidRequest = null,
            string idempotencyKey = null,
            CancellationToken cancellationToken = default);
    }
}