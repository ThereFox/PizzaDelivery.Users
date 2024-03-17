using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.App.Service;

public class FeedbackService
{
    public Task<Result> GetLastNFeedback(){}
    public Task<Result> GetMiddleScoreByDay(){}
    public Task<Result> GetLowestScoreFeedbackByDay(){}
}
