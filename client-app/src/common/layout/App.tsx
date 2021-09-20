import React, { useEffect, useState } from "react";
import logo from "../../logo.svg";
import axios from "axios";
import { Posts } from "./models/posts";
function App() {
  const [posts, setActivity] = useState<Posts[]>([]);
  useEffect(() => {
    axios.get("http://localhost:5000/api/v1/posts/getall").then((res) => {
      console.log(res);
      setActivity(res.data);
    });
  }, []);
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
          {posts.map((post) => (
            <li key={post.id}>{post.post}</li>
          ))}
        </ul>
      </header>
    </div>
  );
}

export default App;
