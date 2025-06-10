const express = require('express');
const router = express.Router();
const { userSchema } = require('../validators/userValidator');

let users = []; // In-memory store

// CREATE
router.post('/', (req, res) => {
  const { error } = userSchema.validate(req.body);
  if (error) return res.status(400).json({ error: error.details[0].message });

  const newUser = { id: Date.now().toString(), ...req.body };
  users.push(newUser);
  res.status(201).json(newUser);
});

// READ ALL
router.get('/', (req, res) => {
  res.json(users);
});

// UPDATE
router.put('/:id', (req, res) => {
  const { error } = userSchema.validate(req.body);
  if (error) return res.status(400).json({ error: error.details[0].message });

  const userIndex = users.findIndex(u => u.id === req.params.id);
  if (userIndex === -1) return res.status(404).json({ message: 'User not found' });

  users[userIndex] = { id: req.params.id, ...req.body };
  res.json(users[userIndex]);
});

// DELETE
router.delete('/:id', (req, res) => {
  users = users.filter(u => u.id !== req.params.id);
  res.status(204).send();
});

module.exports = router;
