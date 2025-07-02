import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import LoginPage from "./pages/LoginPage";
import RegisterPage from "./pages/RegisterPage";
import PrizeListPage from './pages/PrizeList';
import HomePage from "./components/HomePage";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/login" element={<LoginPage />} />
        <Route path="/homePage" element={<HomePage />} />
        <Route path="/register" element={<RegisterPage />} />
        <Route path="/prizes" element={<PrizeListPage />} />
      </Routes>
    </Router>
  );
}

export default App;




