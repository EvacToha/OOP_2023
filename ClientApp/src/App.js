import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import MainLayout from "./layouts/mainLayout";
import WriterPage from "./pages/writerPage";
import HomePage from "./pages/homePage";
import UserPage from "./pages/userPage";
import LeaderBoardPage from "./pages/leaderBoardPage";
import NotFoundPage from "./pages/notFoundPage";
import AuthorizationPage from "./pages/authorizationPage";

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <Routes>
          <Route path={"/"} element={<MainLayout />}>
            <Route index element={<HomePage />} />
            <Route path={"writer"} element={<WriterPage />} />
            <Route path={"user"} element={<UserPage />} />
            <Route path={"leaderboard"} element={<LeaderBoardPage />} />
            <Route path={"authorization"} element={<AuthorizationPage />} />
            <Route path={"*"} element={<NotFoundPage />} />
          </Route>
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
