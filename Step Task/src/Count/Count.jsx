import React, { useState } from "react";

function Counter() {
    const [stepSize, setStepSize] = useState(0);
    const [count, setCount] = useState(0);
  
    const increment = () => {
      setCount(count + stepSize);
    };
  
    const decrement = () => {
      setCount(count - stepSize);
    };
  
    const handleStepIncrease = () => {
      setStepSize(stepSize + 1);
    };
  
    const handleStepDecrease = () => {
      if (stepSize > 1) {
        setStepSize(stepSize - 1);
      }
    };
  
    return (
      <div>
        <h2>Размер Шага : </h2>
        <div>
          <div>
            Размер шага: {stepSize}
          </div>
          <button onClick={handleStepIncrease}>Увеличить шаг</button>
          <button onClick={handleStepDecrease}>Уменьшить шаг</button>
        </div>
        <br/>
        <h2>Счетчик</h2>
        <div>
          <button onClick={decrement}>Уменьшить</button>
          <span>{count}</span>
          <button onClick={increment}>Увеличить</button>
        </div>
      </div>
    );
  }

export default Counter;