import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import './App.css';
import LandingPage from './pages/LandingPage';
import EntertainersPage from './pages/EntertainersPage';
import EntertainerDetailsPage from './pages/EntertainerDetailsPage';
import AddEntertainerPage from './pages/AddEntertainerPage';
import EditEntertainerPage from './pages/EditEntertainerPage';
import Navbar from './components/Navbar';

function App() {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route path="/" element={<LandingPage />} />
        <Route path="/entertainers" element={<EntertainersPage />} />
        <Route path="/entertainers/new" element={<AddEntertainerPage />} />
        <Route path="/entertainers/:entertainerId" element={<EntertainerDetailsPage />} />
        <Route path="/entertainers/:entertainerId/edit" element={<EditEntertainerPage />} />
      </Routes>
    </Router>
  );
}

export default App;