
import { useState, useEffect, useRef } from 'react';
import './App.css';


const BOARD_SIZE = 20;
const INITIAL_SNAKE = [
  { x: 8, y: 10 },
  { x: 7, y: 10 },
  { x: 6, y: 10 },
];
type DirectionKey = 'ArrowUp' | 'ArrowDown' | 'ArrowLeft' | 'ArrowRight';
const DIRECTIONS: Record<DirectionKey, { x: number; y: number }> = {
  ArrowUp: { x: 0, y: -1 },
  ArrowDown: { x: 0, y: 1 },
  ArrowLeft: { x: -1, y: 0 },
  ArrowRight: { x: 1, y: 0 },
};


function getRandomPosition(snake: { x: number; y: number }[]): { x: number; y: number } {
  let position: { x: number; y: number };
  do {
    position = {
      x: Math.floor(Math.random() * BOARD_SIZE),
      y: Math.floor(Math.random() * BOARD_SIZE),
    };
  } while (snake.some(seg => seg.x === position.x && seg.y === position.y));
  return position;
}

function App() {
  const [snake, setSnake] = useState(INITIAL_SNAKE);
  const [direction, setDirection] = useState<DirectionKey>('ArrowRight');
  const directionRef = useRef<DirectionKey>(direction);
  const [food, setFood] = useState(getRandomPosition(INITIAL_SNAKE));
  const [gameOver, setGameOver] = useState(false);

  // Update directionRef whenever direction changes
  useEffect(() => {
    directionRef.current = direction;
  }, [direction]);

  // Keyboard controls
  useEffect(() => {
    const handleKeyDown = (e: KeyboardEvent) => {
      if ((['ArrowUp', 'ArrowDown', 'ArrowLeft', 'ArrowRight'] as DirectionKey[]).includes(e.key as DirectionKey)) {
        setDirection(prev => {
          // Prevent reversing direction
          const opposite: Record<DirectionKey, DirectionKey> = {
            ArrowUp: 'ArrowDown',
            ArrowDown: 'ArrowUp',
            ArrowLeft: 'ArrowRight',
            ArrowRight: 'ArrowLeft',
          };
          const key = e.key as DirectionKey;
          return key === opposite[prev] ? prev : key;
        });
      }
    };
    window.addEventListener('keydown', handleKeyDown);
    return () => window.removeEventListener('keydown', handleKeyDown);
  }, []);

  // Game loop
  useEffect(() => {
    if (gameOver) return;
    const interval = setInterval(() => {
      setSnake(prevSnake => {
        const head = prevSnake[0];
        const move = DIRECTIONS[directionRef.current];
        const newHead = {
          x: (head.x + move.x + BOARD_SIZE) % BOARD_SIZE,
          y: (head.y + move.y + BOARD_SIZE) % BOARD_SIZE,
        };

        // Check collision with self
        if (prevSnake.some(seg => seg.x === newHead.x && seg.y === newHead.y)) {
          setGameOver(true);
          return prevSnake;
        }

        // Check if food is eaten
        if (newHead.x === food.x && newHead.y === food.y) {
          setFood(getRandomPosition([newHead, ...prevSnake]));
          return [newHead, ...prevSnake]; // Grow snake
        }

        return [newHead, ...prevSnake.slice(0, -1)];
      });
    }, 120);
    return () => clearInterval(interval);
  }, [food, gameOver]);

  const handleRestart = () => {
    setSnake(INITIAL_SNAKE);
    setDirection('ArrowRight');
    setFood(getRandomPosition(INITIAL_SNAKE));
    setGameOver(false);
  };

  return (
    <div className="snake-container">
      <h1>Snake Game</h1>
      {gameOver && (
        <div className="game-over">
          <h2>Game Over!</h2>
          <button onClick={handleRestart}>Restart</button>
        </div>
      )}
      <div className="board">
        {Array.from({ length: BOARD_SIZE }).map((_, row) => (
          <div className="board-row" key={row}>
            {Array.from({ length: BOARD_SIZE }).map((_, col) => {
              const isSnake = snake.some(seg => seg.x === col && seg.y === row);
              const isFood = food.x === col && food.y === row;
              return (
                <div
                  key={col}
                  className={isSnake ? 'cell snake' : isFood ? 'cell food' : 'cell'}
                />
              );
            })}
          </div>
        ))}
      </div>
    </div>
  );
}

export default App;
