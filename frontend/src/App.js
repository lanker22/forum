import React, { useEffect, useState } from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import UserContext from "./components/UserContext";
import Home from "./components/Home";
import Login from "./components/Login";
import Register from "./components/Register";

function App() {
  const [user, setUser] = useState(localStorage.getItem("user"));

  const verifyToken = async () => {
    const response = await fetch("http://localhost:5000/api/users/verify", {
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
    });
    if (response.status !== 200) {
      localStorage.setItem("user", "");
      setUser("");
    } else {
      try {
        var data = await response.text();
        localStorage.setItem("user", data);
        setUser(data);
      } catch (err) {
        console.log(err);
      }
    }
  };

  useEffect(() => {
    verifyToken();
  }, []);

  return (
    <div className="App">
      <UserContext.Provider value={[user, setUser]}>
        <BrowserRouter>
          <Switch>
            <Route path="/login" component={Login} />
            <Route path="/register" component={Register} />
            <Route path="/" component={Home} />
          </Switch>
        </BrowserRouter>
      </UserContext.Provider>
    </div>
  );
}

export default App;
