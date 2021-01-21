import React from "react";

const Loading = () => {
  console.log("rendered loading");
  return (
    <div className="loader text-center">
      <div className="loader-inner">
        <div className="lds-roller mb-3">
          <div></div>
          <div></div>
          <div></div>
          <div></div>
          <div></div>
          <div></div>
          <div></div>
          <div></div>
        </div>
      </div>
    </div>
  );
};

export default Loading;
