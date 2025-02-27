﻿using Checkout.Workflows.Actions.Request;
using Checkout.Workflows.Actions.Response;
using Checkout.Workflows.Conditions.Request;
using Checkout.Workflows.Events;
using Checkout.Workflows.Reflows;
using System.Threading.Tasks;

namespace Checkout.Workflows
{
    public interface IWorkflowsClient
    {
        Task<CreateWorkflowResponse> CreateWorkflow(CreateWorkflowRequest createWorkflowRequest);

        Task<GetWorkflowsResponse> GetWorkflows();

        Task<GetWorkflowResponse> GetWorkflow(string workflowId);

        Task<UpdateWorkflowResponse> UpdateWorkflow(string workflowId, UpdateWorkflowRequest updateWorkflowRequest);

        Task<EmptyResponse> RemoveWorkflow(string workflowId);

        Task<EmptyResponse> UpdateWorkflowAction(string workflowId, string actionId,
            WorkflowActionRequest workflowActionRequest);

        Task<EmptyResponse> UpdateWorkflowCondition(string workflowId, string conditionId,
            WorkflowConditionRequest workflowConditionRequest);

        Task<ItemsResponse<EventTypesResponse>> GetEventTypes();

        Task<SubjectEventsResponse> GetSubjectEvents(string subjectId);

        Task<GetEventResponse> GetEvent(string eventId);

        Task<ReflowResponse> ReflowByEvent(string eventId);

        Task<ReflowResponse> ReflowBySubject(string subjectId);

        Task<ReflowResponse> ReflowByEventAndWorkflow(string eventId, string workflowId);

        Task<ReflowResponse> ReflowBySubjectAndWorkflow(string subjectId, string workflowId);

        Task<ReflowResponse> Reflow(ReflowRequest reflowRequest);

        Task<WorkflowActionInvocationsResponse> GetActionInvocations(string eventId, string actionId);
    }
}