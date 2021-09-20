import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import "./App.css";
import axios from "axios";
function App() {
  const [weather, setActivity] = useState([]);
  useEffect(() => {
    axios.get("http://localhost:5000/WeatherForecast").then((res) => {
      console.log(res);
      setActivity(res.data);
    });
  },[]);
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        {/* <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a> */}
        <ul>
          {weather.map((weather: any) => (
            <li key={weather.temperatureC}>{weather.summary}</li>
          ))}
        </ul>
      </header>
    </div>
  );
}

export default App;
