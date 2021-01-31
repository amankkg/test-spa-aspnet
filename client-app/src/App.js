import logo from './logo.svg';
import './App.css';

const array = [0, 1, 2]

function Paragraph(props) {
  console.log('my props', props)

  return (
    <p>
      {props.index + 1}) Edit <code>src/App.js</code> and save to reload.
    </p>
  )
}

function App() {
  const paragraphs = array.map((index) =>
    <Paragraph key={index} index={index} />)

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        {paragraphs}
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
