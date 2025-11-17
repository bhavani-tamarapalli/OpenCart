# OpenCart

This project is a practice workspace featuring a React-based Snake game and Playwright automation resources.

## Features
- **Snake Game**: Classic snake game built with React and TypeScript. Move the snake with arrow keys, eat food to grow, and restart after collision.
- **Playwright Resources**: Includes documentation and feature lists for Playwright end-to-end testing.

## Getting Started

### Prerequisites
- Node.js (latest LTS recommended)
- npm or yarn

### Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/bhavani-tamarapalli/OpenCart.git
   ```
2. Install dependencies:
   ```sh
   cd Snake
   npm install
   ```
3. Start the development server:
   ```sh
   npm run dev
   ```

### Playwright Setup
- See `PLAYWRIGHT_FEATURES.md` for a list of Playwright features and documentation links.
- To add Playwright tests, run:
   ```sh
   npm init playwright@latest
   ```

## Project Structure
```
Snake/
  public/
  src/
    App.tsx
    App.css
    ...
  package.json
  README.md
  PLAYWRIGHT_FEATURES.md
.github/
  agents/
    playwrite.agent.md
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
This project is for practice and educational purposes.
