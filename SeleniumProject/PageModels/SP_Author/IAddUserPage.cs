namespace SeleniumProject.PageModels
{
    interface IAddUserPage
    {
        void clickSave();
        void fillIn(string name, string firstname, string lastname, string email, string password, string verifypassword);
    }
}