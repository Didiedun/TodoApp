import React from 'react';
import TodoList from './components/TodoList';
import './App.css';

function App() {
  return (
    <div className="app">
      <header className="app-header">
        <div className="header-content">
          <h1>Todo Application</h1>
        </div>
      </header>
      <main className="app-main">
        <TodoList />
      </main>
      <footer className="app-footer">
        <p>Built with React and .NET Core - {new Date().getFullYear()}</p>
      </footer>
    </div>
  );
}

export default App;