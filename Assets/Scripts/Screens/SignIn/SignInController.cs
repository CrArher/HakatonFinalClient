namespace Screens.SignIn
{
    public class SignInController : IController
    {
        private readonly GlobalContext _context;
        private readonly SignInComponent _component;

        public SignInController(GlobalContext context, SignInComponent component)
        {
            _context = context;
            _component = component;
        }
        
        public void Deactivate()
        {
            
        }

        public void Activate()
        {
            
        }
    }
}