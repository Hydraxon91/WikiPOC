---
name: wikipoc-mcp
description: Use when calling wikipoc-mcp tools to read or write WikiPOC articles, forum posts, categories, user roles, or the Agent Notes category. Triggers on wikipoc-mcp, MCP wiki tools, wiki page creation/editing, forum operations, moderation workflows, and persistent agent memory across sessions.
---

# WikiPOC MCP — SKILL

## What this skill does

This skill governs when and how the agent uses the WikiPOC MCP server
(`wikipoc-mcp`). The MCP provides 35 tools covering public read, auth,
moderation, and write operations against the WikiPOC platform.

There are two distinct use cases:
1. **Long-term memory** — storing and reading project decisions, bug
   findings, architecture notes, and session context in WikiPOC's
   "Agent Notes" category, so knowledge persists across sessions.
2. **Live testing** — verifying that code fixes actually work by
   calling the running WikiPOC instance through MCP tools, rather
   than just reading source code and assuming correctness.

---

## Environment

**Local development (default for active coding sessions):**
MCP base URL: `http://localhost:5050`
Use this when: Docker Compose is running locally and you're making or
testing backend/frontend changes. Local is the right target for
verifying fixes before they go to Azure.

**Azure (deployed production):**
MCP base URL: WikiPOC Azure App Service URL
Use this when: explicitly asked to verify something on the deployed
version, or after a merge to main.

Never assume Azure reflects recent code changes — backend changes only
deploy to Azure on merge to main. When in doubt, ask which environment
to test against.

---

## Session start behavior (proactive)

At the start of every session, before doing anything else:

1. Call `ensure_agent_notes_category` to confirm the Agent Notes
   category exists.
2. Call `search_wiki_articles("session handoff")` to check for a
   recent handoff note — if one exists, read it with `get_wiki_article`
   and use it as context for this session.
3. Call `search_wiki_articles("architecture")` and
   `search_wiki_articles("known issues")` to load any relevant
   persistent context.

Do not block on this — if the MCP is unavailable (e.g. Docker isn't
running), note it once and proceed without it. Don't retry repeatedly
or ask the user to start Docker before every task.

---

## Long-term memory — when to write

Write to WikiPOC (using `create_wiki_page` or `update_wiki_page`,
always in the "Agent Notes" category) after:

- **Resolving a significant bug** — document: what the symptom was,
  what the root cause turned out to be, what the fix was, and any
  relevant file/line references. Title format: `Bug: [short description]`
- **Making an architecture or design decision** — document: what was
  decided, what alternatives were considered, why this approach was
  chosen. Title format: `Decision: [short description]`
- **End of a long session** — write a session handoff note covering:
  current state of in-progress work, what was completed, what's next.
  Title format: `Session Handoff: [date]`
- **Discovering a non-obvious gotcha** — anything that would take
  significant time to re-diagnose if encountered again.
  Title format: `Gotcha: [short description]`

**Do not write agent notes for:**
- Routine small fixes (CSS tweaks, typo corrections, minor refactors)
- Things already documented in AGENTS.md or RESPONSIVE_DESIGN_PLAN.md
- Speculative findings that weren't confirmed

Always check `search_wiki_articles` for an existing note on the same
topic before creating a new one — update the existing article rather
than creating duplicates.

---

## Live testing — when and how

Use MCP tools to verify fixes rather than just reading code when:

- A bug was reported by the user and you've made a fix — verify the
  fix actually works end-to-end, don't just assert it should work
- An auth/permission issue is being debugged — use `login` to get a
  real token, then call the relevant endpoint tool to confirm the
  response
- A forum or wiki feature was changed — use the relevant read tools
  to confirm the data shape is correct after the fix

**Live testing workflow:**
1. Call `login` with test credentials to get a session token
2. Call the relevant tool(s) to exercise the fixed feature
3. Confirm the response matches expected behavior
4. If it doesn't, report the discrepancy rather than silently
   assuming it's a test environment issue

**Test credentials to use** (from .env — do not hardcode in MCP):
- Admin/Owner: `admin@admin.com` / `AdminPass123`
- Regular user: `test@test.com` / `TestPass123`

**Do not use MCP live testing as a substitute for the NUnit test
suite.** MCP testing is for smoke-testing specific fixes end-to-end.
Full regression testing still uses `dotnet test`.

---

## Tool reference by use case

### Session start / context loading
- `ensure_agent_notes_category` — confirm Agent Notes category exists
- `search_wiki_articles(query)` — find existing notes on a topic
- `get_wiki_article(slug)` — read a specific note in full
- `list_categories` — check available categories

### Writing project memory
- `create_wiki_page(title, content, siteSub?, roleNote?, categoryId?)` — new note
- `update_wiki_page(id, title?, content?, siteSub?, roleNote?, categoryId?)` — update existing
- `search_wiki_articles(query)` — check for duplicates before creating

### Live testing — public/read
- `get_wiki_articles` — list all articles
- `get_wiki_article(slug)` — read specific article
- `search_wiki_articles(query)` — search articles by title/content
- `list_forum_topics` — list forum categories
- `get_forum_topic(slug)` — read a forum topic
- `search_forum_topics(query)` — search topics by title/description
- `get_forum_post(slug)` — read a forum post with comments
- `search_forum_posts(topicId, query)` — search posts within a topic
- `list_categories` — list all categories

### Live testing — auth flows
- `login(email, password)` — authenticate, get token
- `register(email, username, password)` — test registration flow

### Live testing — write operations (requires login first)
- `create_wiki_page(title, content?, siteSub?, roleNote?, categoryId?)` — test page creation
- `update_wiki_page(id, title?, content?, siteSub?, roleNote?, categoryId?)` — test page editing
- `delete_wiki_page(id)` — test page deletion (destructive — Moderator+)
- `post_wiki_comment(content, wikiPageId, userProfileId)` — test wiki comment posting
- `edit_wiki_comment(id, content)` — test wiki comment editing
- `delete_wiki_comment(id)` — test wiki comment deletion (destructive)
- `create_forum_post(postTitle, content, forumTopicId, userProfileId, userName)` — test forum post creation
- `update_forum_post(id, postTitle?, content?)` — test forum post editing
- `delete_forum_post(id)` — test forum post deletion (destructive)
- `post_forum_comment(content, forumPostId, userProfileId)` — test comment posting
- `edit_forum_comment(id, content)` — test comment editing
- `delete_forum_comment(id)` — test comment deletion (destructive)
- `create_forum_topic(title, description)` — test topic creation (Admin+)
- `create_category(name)` — test category creation (Admin+)

### Live testing — moderation flows
- `get_submitted_pages` — check new-page approval queue
- `get_submitted_updates` — check update approval queue
- `get_submitted_page_by_id(id)` — read full submitted new-page content
- `get_submitted_update_by_id(id)` — read full submitted update content
- `approve_submitted_page(id)` — approve a new page (Moderator+)
- `approve_submitted_update(id)` — approve an update (Moderator+)
- `decline_submitted_page(id)` — decline a new page (destructive — Moderator+)
- `get_users` — verify user list (Admin+)
- `update_user_role(userId, role)` — test role changes (destructive — Admin+)

---

## What NOT to do

- Do not write agent notes for every small action — only significant
  findings worth preserving across sessions
- Do not test against Azure without being explicitly asked — local
  Docker is always the default for active development
- Do not create duplicate articles — search first, update if exists
- Do not use MCP tools to bypass the user's confirmation workflow —
  destructive MCP operations (delete_wiki_page, delete_forum_post,
  delete_forum_comment, delete_wiki_comment, update_user_role,
  decline_submitted_page) follow the same confirmation rules as
  destructive code changes in AGENTS.md
- Do not expose test credentials in committed code or logs
