namespace SH.Model {
    public interface IState
    {
        void Initialize();

        void Execute(float delta);

        void LateExecute();

        void Exit();

    }
}
