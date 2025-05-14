import React from 'react';
import './TodoItem.css'; // We'll create this CSS file later

const TodoItem = ({ todo, onToggle, onEdit, onDelete }) => {
  return (
    <div className={`todo-item ${todo.isCompleted ? 'completed' : ''}`}>
      <div className="todo-content">
        <input
          type="checkbox"
          checked={todo.isCompleted}
          onChange={() => onToggle(todo.id, !todo.isCompleted)}
          className="todo-checkbox"
        />
        <div className="todo-text">
          <h3 className={todo.isCompleted ? 'completed-text' : ''}>
            {todo.title}
          </h3>
          {todo.description && (
            <p className={todo.isCompleted ? 'completed-text' : ''}>
              {todo.description}
            </p>
          )}
          <p className="todo-date">
            Created: {new Date(todo.createdAt).toLocaleDateString()}
            {todo.completedAt && ` • Completed: ${new Date(todo.completedAt).toLocaleDateString()}`}
          </p>
        </div>
      </div>
      
      <div className="todo-actions">
        <button onClick={() => onEdit(todo)} className="edit-button">
          Edit
        </button>
        <button onClick={() => onDelete(todo.id)} className="delete-button">
          Delete
        </button>
      </div>
    </div>
  );
};

export default TodoItem;