import logo from './logo.svg';
import './App.css';
import ForecastEntry from './Forecast'

async function fetchForecast() {
  const resp = await fetch('/weatherforecast')
  const data = await resp.json()

  return data
}

function App() {
  const forecastArray = []
  let count = 0

  const onClick = () => {
    count += 1
    console.log('increment', count)
  }

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        {forecastArray.map((f, i) =>
          <ForecastEntry
            key={i}
            index={i}
            date={f.date}
            temperatureC={f.temperatureC}
            summary={f.summary}
          />
        )}
        <span className="App-link">
          {count}
        </span>
        <button onClick={onClick}>increment</button>
      </header>
    </div>
  );
}

export default App;
