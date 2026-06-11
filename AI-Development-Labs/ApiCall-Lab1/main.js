
// ── STATE ──────────────────────────────────────────────
let mode = 'text'; // text | image
let conversations = {}; // { [id]: { id, title, messages: [{role,content}], model, mode, createdAt } }
let activeId = null;
let isLoading = false;

const TEXT_SUGGESTIONS = [
  'Explain async/await in C#',
  'Write a SQL query for pagination',
  'What is Clean Architecture?',
];

const IMAGE_SUGGESTIONS = [
  'A futuristic city at night',
  'Abstract geometric art',
  'A serene mountain landscape'
];

// ── INIT ───────────────────────────────────────────────
function init() {
  //loadSessions();
  updateKeyUI();
  updateChips();
  newChat();
}

// ── SESSION MANAGEMENT ─────────────────────────────────
// function loadSessions() {
//   try {
    // const saved = sessionStorage.getItem('ai_chat_sessions');
    // if (saved) {
    //   const ids = JSON.parse(saved);
    //   // Only load metadata (titles, ids, model, mode)
    //   ids.forEach(id => {
    //     const meta = sessionStorage.getItem('ai_meta_' + id);
    //     if (meta) {
    //       const parsed = JSON.parse(meta);
    //       conversations[id] = { ...parsed, messages: [] };
    //     }
    //   });
    // }
//   } catch (e) { }
//   renderSessionList();
// }

function saveSessions() {
    console.log("saveSessions()");
  try {
    const ids = Object.keys(conversations);
    sessionStorage.setItem('ai_chat_sessions', JSON.stringify(ids));
    ids.forEach(id => {
      const { messages, ...meta } = conversations[id];
      sessionStorage.setItem('ai_meta_' + id, JSON.stringify(meta));
    });
  } catch (e) {}
}

function newChat() {
    console.log("newChat()");
  const id = 'chat_' + Date.now();
  conversations[id] = {
    id,
    title: 'New chat',
    messages: [],
    model: document.getElementById('model-select').value,
    mode: mode,
    createdAt: Date.now(),
  };
  activeId = id;
  saveSessions();
  renderSessionList();
  renderMessages();
  document.getElementById('chat-title').textContent = 'New chat';
  document.getElementById('user-input').focus();
}

function switchSession(id) {
    console.log("switchSession()");
  if (id === activeId) return;
  activeId = id;
  const conv = conversations[id];
  if (conv) {
    setMode(conv.mode || 'text', false);
    const modelSelect = document.getElementById('model-select');
    if (conv.model) modelSelect.value = conv.model;
    document.getElementById('chat-title').textContent = conv.title;
  }
  renderSessionList();
  renderMessages();
}

function deleteSession(id, e) {
  e.stopPropagation();
  if (Object.keys(conversations).length === 1) { toast('Cannot delete the only chat'); return; }
  sessionStorage.removeItem('ai_meta_' + id);
  delete conversations[id];
  saveSessions();
  if (activeId === id) {
    const remaining = Object.keys(conversations);
    activeId = remaining[remaining.length - 1];
    const conv = conversations[activeId];
    if (conv) {
      setMode(conv.mode || 'text', false);
      document.getElementById('chat-title').textContent = conv.title;
    }
    renderMessages();
  }
  renderSessionList();  
}

function renderSessionList() {
  const list = document.getElementById('session-list');
  const ids = Object.keys(conversations).sort((a, b) => (conversations[b].createdAt || 0) - (conversations[a].createdAt || 0));

  if (ids.length === 0) {
    list.innerHTML = '<div class="no-sessions">No chats yet</div>';
    return;
  }

  list.innerHTML = ids.map(id => {
    const c = conversations[id];
    const icon = (c.mode === 'image') ? '🖼' : '💬';
    const isActive = id === activeId;
    return `
      <div class="session-item ${isActive ? 'active' : ''}" onclick="switchSession('${id}')">
        <span class="session-icon">${icon}</span>
        <span class="session-name" title="${escHtml(c.title)}">${escHtml(c.title)}</span>
        <button class="session-delete" onclick="deleteSession('${id}', event)" title="Delete">✕</button>
      </div>
    `;
  }).join('');
}

// ── MODE ───────────────────────────────────────────────
function setMode(m, updateModel = true) {
    console.log("setMode()");
  mode = m;
  document.getElementById('btn-text').classList.toggle('active', m === 'text');
  document.getElementById('btn-image').classList.toggle('active', m === 'image');
  document.getElementById('image-hint').style.display = m === 'image' ? 'block' : 'none';
  document.getElementById('user-input').placeholder = m === 'image' ? 'Describe the image you want to generate…' : 'Send a message…';
  updateChips();

  if (updateModel) {
    const sel = document.getElementById('model-select');
    if (m === 'image' && !isImageModel(sel.value)) {
      sel.value = 'gpt-image-1-mini';
    } else if (m === 'text' && isImageModel(sel.value)) {
        sel.value = 'gpt-4o-mini';
      }
  }

  if (activeId && conversations[activeId]) {
    conversations[activeId].mode = m;
    saveSessions();
  }
}

function onModelChange() {
  const val = document.getElementById('model-select').value;
  if (isImageModel(val) && mode !== 'image') setMode('image', false);
  else if (!isImageModel(val) && mode !== 'text') setMode('text', false);
  if (activeId && conversations[activeId]) {
    conversations[activeId].model = val;
    saveSessions();
  }
}
// is the given model value an image generation model?
function isImageModel(val) {
  return val === 'gpt-image-1-mini';
}

// ── RENDER MESSAGES ────────────────────────────────────
function renderMessages() {
    console.log("renderMessages()");
  const conv = conversations[activeId];
  const container = document.getElementById('messages');

  if (!conv || conv.messages.length === 0) {
    container.innerHTML = `
      <div id="empty-state">
        <div class="empty-icon">✦</div>
        <h2>Start a conversation</h2>
        <p>Use <strong>Text</strong> mode for chat or <strong>Image</strong> mode to generate images.</p>
        <div class="suggestion-chips" id="chips"></div>
      </div>
    `;
    updateChips();
    return;
  }

  container.innerHTML = conv.messages.map((msg, i) => renderMessageRow(msg, i)).join('');
  scrollToBottom();
}

function renderMessageRow(msg, idx) {
    console.log("renderMessageRow()");
  const isUser = msg.role === 'user';
  const senderLabel = isUser ? 'user' : 'developer';

  let content = '';
  if (msg.image_url) {
    content = `<img class="gen-image" src="${escHtml(msg.image_url)}" alt="Generated image" loading="lazy" />`;
  } else if (msg.error) {
    content = `<div class="bubble error">${escHtml(msg.content)}</div>`;
  } else {
    const rendered = renderText(msg.content || '');
    const imgPreview = msg.input_image_url
      ? `<img class="gen-image" src="${escHtml(msg.input_image_url)}" alt="Input image" loading="lazy" style="max-width:220px; margin-top:8px;" />`
      : '';
    content = `<div class="bubble ${isUser ? 'user' : 'ai'}">${rendered}${imgPreview}</div>`;
  }

  return `
    <div class="msg-row ${isUser ? 'user' : 'ai'}">
      <div class="avatar ${isUser ? 'user' : 'ai'}">${isUser ? 'U' : 'AI'}</div>
      <div class="msg-body">
        <div class="msg-sender">${senderLabel}</div>
        ${content}
      </div>
    </div>
  `;
}

function renderText(text) {
    console.log("renderText()");
  // Very lightweight markdown-like rendering
  let s = escHtml(text);
  // Code blocks
  s = s.replace(/```(\w*)\n?([\s\S]*?)```/g, (_, lang, code) =>
    `<pre><code>${code.trim()}</code></pre>`
  );
  // Inline code
  s = s.replace(/`([^`\n]+)`/g, '<code>$1</code>');
  // Bold
  s = s.replace(/\*\*(.*?)\*\*/g, '<strong>$1</strong>');
  // Italic
  s = s.replace(/\*(.*?)\*/g, '<em>$1</em>');
  // Newlines → <br> (outside pre blocks)
  s = s.replace(/\n/g, '<br>');
  return s;
}

function escHtml(str) {
  return (str || '').replace(/&/g,'&amp;').replace(/</g,'&lt;').replace(/>/g,'&gt;').replace(/"/g,'&quot;');
}

// ── SEND MESSAGE ───────────────────────────────────────
async function sendMessage() {
  const input = document.getElementById('user-input');
  const text = input.value.trim();
  if (!text || isLoading) return;

  const apiKey = localStorage.getItem('api_key');
  if (!apiKey) {
    toast('Set your API key first (bottom-left)');
    toggleApiPanel(true);
    return;
  }

  const conv = conversations[activeId];
  if (!conv) return;

  // Grab optional image URL (vision models)
  const imageUrlInput = document.getElementById('image-url-input');
  const imageUrl = imageUrlInput ? imageUrlInput.value.trim() : '';

  // User message — store image_url separately for display, not sent to API as-is
  conv.messages.push({ role: 'user', content: text, ...(imageUrl && { input_image_url: imageUrl }) });

  // Auto-title after first message
  if (conv.messages.length === 1) {
    const title = text.length > 40 ? text.slice(0, 40) + '…' : text;
    conv.title = title;
    document.getElementById('chat-title').textContent = title;
    saveSessions();
    renderSessionList();
  }

  input.value = '';
  if (imageUrlInput) imageUrlInput.value = '';
  autoResize(input);
  updateSendBtn();
  isLoading = true;

  renderMessages();
  appendLoadingRow();

  try {
    const model = document.getElementById('model-select').value;

    if (mode === 'image') {
      await handleImageRequest(text, apiKey, model, conv);
    } else {
      await handleTextRequest(text, apiKey, model, conv);
    }
  } catch (err) {
    removeLoadingRow();
    conv.messages.push({ role: 'assistant', content: 'Error: ' + err.message, error: true });
    renderMessages();
  }

  isLoading = false;
  updateSendBtn();
}

async function handleTextRequest(text, apiKey, model, conv) {
  const history = conv.messages
  .slice(0, -1)
  .filter(m => !m.error)
  .map(({ role, content }) => ({ role, content }))
  .slice(-4);

  const body = {
    model,
    stream: true,
    input: [
      { role: 'system', content: 'You are a helpful, concise, and senior assistant.' },
      ...history,
      { role: 'user', content: text },
    ],
  };

  const resp = await fetch('https://api.openai.com/v1/responses', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + apiKey,
    },
    body: JSON.stringify(body),
  });

  if (!resp.ok) {
    const errData = await resp.json().catch(() => ({}));
    throw new Error(errData.error?.message || `HTTP ${resp.status}`);
  }

  removeLoadingRow();

  const aiMsg = { role: 'assistant', content: '' };
  conv.messages.push(aiMsg);
  renderMessages();

  const reader = resp.body.getReader();
  const decoder = new TextDecoder();
  let buffer = '';
  let msgEl = null;

  while (true) {
    const { done, value } = await reader.read();
    if (done) break;
    buffer += decoder.decode(value, { stream: true });

    const lines = buffer.split('\n');
    buffer = lines.pop();

    for (const line of lines) {
      if (!line.startsWith('data: ')) continue;
      const chunk = line.slice(6).trim();
      if (!chunk || chunk === '[DONE]') continue;
      try {
        const parsed = JSON.parse(chunk);
        // Responses API streaming event type
        if (parsed.type === 'response.output_text.delta') {
          const delta = parsed.delta || '';
          if (delta) {
            aiMsg.content += delta;
            if (!msgEl) msgEl = getLastAiBubble();
            if (msgEl) {
              msgEl.innerHTML = renderText(aiMsg.content);
              msgEl.classList.add('stream-cursor');
            }
          }
        }
      } catch (_) {}
    }
  }

  if (msgEl) msgEl.classList.remove('stream-cursor');
  scrollToBottom();
}

// ── IMAGE GENERATION ───────────────────────────────────
async function handleImageRequest(prompt, apiKey, model, conv) {
  const body = {
    model: 'gpt-image-1-mini',
    prompt,
    n: 1,
    size: '1024x1024',
  };

  const resp = await fetch('https://api.openai.com/v1/images/generations', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + apiKey
    },
    body: JSON.stringify(body),
  });

  removeLoadingRow();

  if (!resp.ok) {
    const errData = await resp.json().catch(() => ({}));
    throw new Error(errData.error?.message || `HTTP ${resp.status}`);
  }

  // gpt-image-1 returns base64 by default — convert to data URL
  const data = await resp.json();
  const b64 = data.data[0].b64_json;
  const url = `data:image/png;base64,${b64}`;

  conv.messages.push({ role: 'assistant', content: prompt, image_url: url });
  renderMessages();
}

// ── DOM HELPERS ────────────────────────────────────────
function appendLoadingRow() {
  const container = document.getElementById('messages');
  const div = document.createElement('div');
  div.className = 'msg-row ai';
  div.id = 'loading-row';
  div.innerHTML = `
    <div class="avatar ai">AI</div>
    <div class="msg-body">
      <div class="msg-sender">Assistant</div>
      <div class="bubble ai">
        <div class="typing-indicator"><span></span><span></span><span></span></div>
      </div>
    </div>
  `;
  container.appendChild(div);
  scrollToBottom();
}

function removeLoadingRow() {
  const row = document.getElementById('loading-row');
  if (row) row.remove();
}

function getLastAiBubble() {
  const bubbles = document.querySelectorAll('.bubble.ai');
  return bubbles[bubbles.length - 1] || null;
}

function scrollToBottom() {
  const container = document.getElementById('messages');
  container.scrollTop = container.scrollHeight;
}

function clearMessages() {
  const conv = conversations[activeId];
  if (!conv || conv.messages.length === 0) return;
  conv.messages = [];
  conv.title = 'New chat';
  document.getElementById('chat-title').textContent = 'New chat';
  saveSessions();
  renderSessionList();
  renderMessages();
  toast('Conversation cleared');
}

// ── INPUT ──────────────────────────────────────────────
function handleKeyDown(e) {
  if (e.key === 'Enter' && !e.shiftKey) {
    e.preventDefault();
    sendMessage();
  }
}

function autoResize(el) {
  el.style.height = 'auto';
  el.style.height = Math.min(el.scrollHeight, 180) + 'px';
}

function updateSendBtn() {
  const btn = document.getElementById('send-btn');
  const val = document.getElementById('user-input').value.trim();
  btn.disabled = !val || isLoading;

  // Approx token count display
  const chars = document.getElementById('user-input').value.length;
  const approx = Math.round(chars / 4);
  document.getElementById('token-count').textContent = approx > 0 ? `~${approx} tokens` : '';
}

// ── API KEY ────────────────────────────────────────────
function toggleApiPanel(forceOpen = false) {
  const panel = document.getElementById('api-key-panel');
  const isOpen = panel.classList.contains('open');
  if (forceOpen || !isOpen) {
    panel.classList.add('open');
    const savedKey = localStorage.getItem('api_key') || '';
    document.getElementById('api-key-input').value = savedKey ? '••••••••' + savedKey.slice(-4) : '';
    document.getElementById('api-key-input').focus();
  } else {
    panel.classList.remove('open');
  }
}

function saveApiKey() {
  const val = document.getElementById('api-key-input').value.trim();
  if (!val || val.includes('•')) {
    toast('Enter a valid API key');
    return;
  }
  localStorage.setItem('api_key', val);
  document.getElementById('api-key-panel').classList.remove('open');
  updateKeyUI();
  toast('API key saved');
}

function updateKeyUI() {
  const key = localStorage.getItem('api_key');
  const dot = document.getElementById('key-dot');
  const label = document.getElementById('key-toggle-label');
  if (key) {
    dot.classList.add('set');
    label.textContent = 'API Key ···' + key.slice(-4);
  } else {
    dot.classList.remove('set');
    label.textContent = 'Set API Key';
  }
}

// ── CHIPS ──────────────────────────────────────────────
function updateChips() {
    console.log("updateChips()");
  const chips = document.getElementById('chips');
  if (!chips) return;
  const suggestions = mode === 'image' ? IMAGE_SUGGESTIONS : TEXT_SUGGESTIONS;
  chips.innerHTML = suggestions.map(s =>
    `<div class="chip" onclick="useChip(this.textContent)">${escHtml(s)}</div>`
  ).join('');
}

function useChip(text) {
  const input = document.getElementById('user-input');
  input.value = text;
  autoResize(input);
  updateSendBtn();
  input.focus();
}

// ── TOAST ──────────────────────────────────────────────
let toastTimer = null;
function toast(msg) {
  const el = document.getElementById('toast');
  el.textContent = msg;
  el.classList.add('show');
  clearTimeout(toastTimer);
  toastTimer = setTimeout(() => el.classList.remove('show'), 2500);
}

// ── BOOT ───────────────────────────────────────────────
init();