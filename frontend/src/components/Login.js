import React, { useState, useContext } from "react";
import { useHistory } from "react-router-dom";
import UserContext from "./UserContext";

var Login = () => {
  const history = useHistory();
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const { auth, user } = useContext(UserContext);
  const [isAuthenticated, setIsAuthenticated] = auth;
  const [applicationUser, setApplicationUser] = user;

  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      Username: username,
      Password: password,
    }),
    credentials: "include",
  };

  const url = "http://localhost:5000/api/users/login";

  const handleSubmit = async (e) => {
    e.preventDefault();
    var response = await fetch(url, requestOptions);
    if (response.status !== 200) {
      return alert("Login error. Try again");
    } else {
      try {
        var data = await response.text();
        setIsAuthenticated(true);
        setApplicationUser(data);
        history.push("/");
      } catch (err) {
        alert("Something went wrong. Try again");
        console.log(err);
      }
    }
  };

  return (
    <div className="login-body">
      <div className="container">
        <div className="main-body p-0">
          <form className="form-signin" onSubmit={handleSubmit}>
            <h1 className="h3 mb-3 font-weight-normal">Please sign in</h1>
            <label className="sr-only">Username</label>
            <input
              className="form-control"
              placeholder="Username"
              required
              autofocus
              onChange={(e) => setUsername(e.target.value)}
              value={username}
            />
            <label className="sr-only">Password</label>
            <input
              type="password"
              className="form-control"
              placeholder="Password"
              required
              onChange={(e) => setPassword(e.target.value)}
              value={password}
            />
            <button className="btn btn-lg btn-primary btn-block" type="submit">
              Sign in
            </button>
            <p className="mt-5 mb-3 text-muted">&copy; 2020-21</p>
          </form>
        </div>
      </div>
    </div>
  );
};

export default Login;
