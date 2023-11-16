using Core;

namespace StateMachine
{
    public class GameplayState : State
    {
        private readonly QuestionGenerator _questionGenerator;

        public GameplayState(QuestionGenerator questionGenerator)
        {
            _questionGenerator = questionGenerator;
        }

        public override void Enter()
        {
            _questionGenerator.Initialize();
        }

        public override void Exit()
        {
            _questionGenerator.Reset();
        }
    }
}
