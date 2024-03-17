using PizzaDelivery.Domain.Entitys.Order;
using PizzaDelivery.GraphQL.Auth.Attributes;
using PizzaDelivery.GraphQL.DTO;
using PizzaDelivery.GraphQL.DTO.OutputeObjects;

namespace PizzaDelivery.GraphQL;

public class Query
{
    [CustomerAuthorise]
    public async Task<CustomerOutputeObject> GetCurrentUserInfo()
    {
        return null;
    }
    
    [AdminAuthorise]
    public async Task<CustomerOutputeObject> GetUserInfo(){
        return null;}
    
    [CustomerAuthorise]
    public async Task<Address> GetOwnMostUsableAddress(){
        return null;}

    [AnyAuthorise]
    public async Task<int> GetOrdersCountByDate(DateOnly date){
        return 1;}
    
    [AnyAuthorise]
    public async Task<int> GetCurrentOrdersCount(){
        return 1;}
    
    [AdminAuthorise]
    public async Task<string> GetMostPopularAddreser(){
        return null;}
    
    [AnyAuthorise]
    public async Task<float> GetPersentOfSucsessfullDelivery(){
        return 1f;}
    
    [AdminAuthorise]
    public async Task<decimal> GetMiddleOrderPrice(){
        return 1;}
    
    [AdminAuthorise]
    public async Task<decimal> GetLowestOrderPrice(){
        return 1;}
    
    [AdminAuthorise]
    public async Task<decimal> GetHightestOrderPrice(){
        return 1;}

    [AnyAuthorise]
    public async Task<List<FeedbackOutputeObject>> GetLastNFeedback(int n){
        return null;}
    
    [AnyAuthorise]
    public async Task<int> GetMiddleScoreByDay(){
        return 1;}
    
    [AdminAuthorise]
    public async Task<FeedbackOutputeObject> GetLowestScoreFeedbackByDay(){
        return null;}

    [AnyAuthorise]
    public async Task<List<OrderOutputeObject>> GetMostPopularNIngridients(int n){
        return null;}
    
    [AnyAuthorise]
    public async Task<List<ProductOutputeObject>> GetNProductsWithIngridient(Guid ingridientId, int n){
        return null;}
    
    [AnyAuthorise]
    public async Task<List<ProductOutputeObject>> GetNProductWithMostContainsIngridient(Guid ingridientId, int n){
        return null;}

    [CustomerAuthorise]
    public async Task<List<ProductOutputeObject>> GetFirstNProduct(int n){
        return null;}
    [AnyAuthorise]
    public async Task<List<ProductOutputeObject>> GetNMostLikedProduct(int n){
        return null;}
    [AnyAuthorise]
    public async Task<List<ProductOutputeObject>> GetNMostOrderedProduct(int n){
        return null;}

}
