import {useEffect} from "react";

function LeaderBoard() {
  const user = {};
  
  useEffect(() => {
    fetch("https://localhost:7233/weatherforecast", {
      // mode: "no-cors",
      method: "get",
      headers: {
        Accept: "application/json",
      },
    })
        .then((response) => {
          if (!response.ok) {
            throw new Error("Bad status code from server.");
          }

          return response.json();
        })
        .then((qwe) => {
          console.log(qwe);
        });
  }, []);
  return (
    <>
      <table className="table">
        <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col">Name</th>
            <th scope="col">Texts</th>
            <th scope="col">Speed</th>
            <th scope="col">Best Speed</th>
            <th scope="col">Error Rate</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <th scope="row">1</th>
            <td>Sanya</td>
            <td>25</td>
            <td>53 sym/sec</td>
            <td>120 sym/sec</td>
            <td>0.05</td>
          </tr>
          <tr>
            <th scope="row">2</th>
            <td>Sanya</td>
            <td>25</td>
            <td>53 sym/sec</td>
            <td>120 sym/sec</td>
            <td>0.05</td>
          </tr>
          <tr>
            <th scope="row">3</th>
            <td>Sanya</td>
            <td>25</td>
            <td>53 sym/sec</td>
            <td>120 sym/sec</td>
            <td>0.05</td>
          </tr>
        </tbody>
      </table>
    </>
  );
}

export default LeaderBoard;
