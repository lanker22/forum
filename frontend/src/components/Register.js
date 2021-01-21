import React, { useState } from "react";
import { useHistory } from "react-router-dom";

var Register = () => {
  const history = useHistory();
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [passwordConfirm, setPasswordConfirm] = useState("");

  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      Username: username,
      Password: password,
      ConfirmPassword: passwordConfirm,
    }),
    credentials: "include",
  };

  const url = "http://localhost:5000/api/accounts/register";

  const handleSubmit = async (e) => {
    e.preventDefault();
    var response = await fetch(url, requestOptions);
    if (response.status !== 200) {
      console.log(response);
      return alert("Login validation error");
    } else {
      try {
        history.push("/login");
      } catch (err) {
        alert("Something went wrong. Try again");
        console.log(err.Message);
      }
    }
  };

  return (
    <div className="login-body">
      <div className="container">
        <div className="main-body p-0">
          <form className="form-signin" onSubmit={handleSubmit}>
            <h1 className="h3 mb-3 font-weight-normal">Create an account</h1>
            <label className="sr-only">Username</label>
            <input
              className="form-control"
              placeholder="Username"
              required
              autoFocus
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
            <label className="sr-only">Confirm Password</label>
            <input
              type="password"
              className="form-control"
              placeholder="Confirm Password"
              required
              onChange={(e) => setPasswordConfirm(e.target.value)}
              value={passwordConfirm}
            />
            <button className="btn btn-lg btn-primary btn-block" type="submit">
              Register
            </button>
            <p className="mt-5 mb-3 text-muted">&copy; 2020-21</p>
          </form>
        </div>
      </div>
    </div>
  );
};

export default Register;
