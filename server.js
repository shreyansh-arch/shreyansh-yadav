const express = require('express');
const cors = require('cors');
const morgan = require('morgan');
const userRoutes = require('./routes/users');
const logger = require('./middleware/logger');
const auth = require('./middleware/auth');

const app = express();
app.use(cors());
app.use(morgan('dev'));
app.use(express.json());
app.use(logger);

// Routes (protected)
app.use('/api/users', auth, userRoutes);

const PORT = process.env.PORT || 3000;
app.listen(PORT, () => console.log(`Server running on port ${PORT}`));
